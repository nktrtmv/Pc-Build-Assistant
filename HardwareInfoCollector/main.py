from parsers.parser import *
from selenium import webdriver
import json
import zipfile
from selenium.webdriver.chrome.service import Service
from config import *
from flask import Flask


def get_chromedriver(manifest, background, use_proxy=False, user_agent=None, driver_number=0):
    chrome_options = webdriver.ChromeOptions()

    if use_proxy:
        plugin_file = f'plugins/proxy_auth_plugin_{driver_number}.zip'

        with zipfile.ZipFile(plugin_file, 'w') as zp:
            zp.writestr(f'manifest.json', manifest)
            zp.writestr(f'background.js', background)

        chrome_options.add_extension(plugin_file)

    if user_agent:
        chrome_options.add_argument(f'--user-agent={user_agent}')

    s = Service(
        executable_path='chrome_drivers/chromedriver_mac_arm64/chromedriver'
    )
    driver = webdriver.Chrome(
        service=s,
        options=chrome_options
    )

    return driver

def collect_data():
    config = Configuration()

    parsers = [Parser(), Parser(), Parser()]

    files_info = [("./hardware_data/aio.txt", 2), ("./hardware_data/air.txt", 3), ("./hardware_data/case.txt", 6),
                  ("./hardware_data/cpu.txt", 6), ("./hardware_data/gpu.txt", 3), ("./hardware_data/mb.txt", 5),
                  ("./hardware_data/power_supply.txt", 6), ("./hardware_data/ram.txt", 5),
                  ("./hardware_data/ssd.txt", 4)]

    k = 0
    for file_info in files_info:
        if k == 0:
            parsers[k].browser = get_chromedriver(manifest=config.manifest_json_1,
                                                  background=config.background_js_1,
                                                  use_proxy=True,
                                                  user_agent=config.get_random_user_agent(),
                                                  driver_number=1)
        elif k == 1:
            parsers[k].browser = get_chromedriver(manifest=config.manifest_json_2,
                                                  background=config.background_js_2,
                                                  use_proxy=True,
                                                  user_agent=config.get_random_user_agent(),
                                                  driver_number=2)
        elif k == 2:
            parsers[k].browser = get_chromedriver(manifest=config.manifest_json_3,
                                                  background=config.background_js_3,
                                                  use_proxy=True,
                                                  user_agent=config.get_random_user_agent(),
                                                  driver_number=3)

        parsed_data = parsers[k].parse_products(*file_info)
        k = (k + 1) % 3
        with open(f"./collected_info/{file_info[0].split('/')[2].split('.')[0]}.json", 'w') as file:
            json.dump(parsed_data, file)

def process_collected_data():
    # list is not empty + price > 0.0 + price < 200000

    files_info = [("./hardware_data/aio.txt", 2), ("./hardware_data/air.txt", 3), ("./hardware_data/case.txt", 6),
                  ("./hardware_data/cpu.txt", 6), ("./hardware_data/gpu.txt", 3), ("./hardware_data/mb.txt", 5),
                  ("./hardware_data/power_supply.txt", 6), ("./hardware_data/ram.txt", 5),
                  ("./hardware_data/ssd.txt", 4)]

    for file_info in files_info:
        with open(file_info[0], "r") as txt_file:
            with open(f"./collected_info/{file_info[0].split('/')[2].split('.')[0]}.json", 'w') as json_file:
                txt_data = txt_file.readlines()
                json_data = json.load(json_file)


def update_database():
    return


app = Flask(__name__)

@app.route('/update-hardware-database')
def update_hardware_data():
    # collect_data()

    # process_collected_data()

    # update_database()

    return "Success"


if __name__ == '__main__':
    app.run(debug=True, port=3000, host="127.0.0.1")
