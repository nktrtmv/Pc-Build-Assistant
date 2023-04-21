from parsers.parser import *
from selenium import webdriver
import json
import zipfile
from selenium.webdriver.chrome.service import Service
from config import *


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


def main():
    config = Configuration()
    chrome_1 = get_chromedriver(manifest=config.manifest_json_1, background=config.background_js_1, use_proxy=True,
                                user_agent=config.get_random_user_agent(), driver_number=1)
    chrome_2 = get_chromedriver(manifest=config.manifest_json_2, background=config.background_js_2, use_proxy=True,
                                user_agent=config.get_random_user_agent(), driver_number=2)
    chrome_3 = get_chromedriver(manifest=config.manifest_json_3, background=config.background_js_3, use_proxy=True,
                                user_agent=config.get_random_user_agent(), driver_number=3)

    parsers = [Parser(chrome_1), Parser(chrome_2), Parser(chrome_3)]

    # parser = Parser()

    files_info = [("./hardware_data/aio.txt", 2), ("./hardware_data/air.txt", 3), ("./hardware_data/case.txt", 6),
                  ("./hardware_data/cpu.txt", 6), ("./hardware_data/gpu.txt", 3), ("./hardware_data/mb.txt", 5),
                  ("./hardware_data/power_supply.txt", 6), ("./hardware_data/ram.txt", 5),
                  ("./hardware_data/ssd.txt", 4)]

    k = 0
    for file_info in files_info[:3]:
        parsed_data = parsers[k].parse_products(*file_info)
        # parsed_data = parser.parse_products(*file_info)
        k = (k + 1) % 3
        with open(f"./collected_info/{file_info[0].split('/')[2].split('.')[0]}.json", 'w') as file:
            json.dump(parsed_data, file)

    for browser in [chrome_1, chrome_2, chrome_3]:
        browser.close()
        browser.quit()


if __name__ == '__main__':
    main()

