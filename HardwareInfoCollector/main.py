from models.aio import AIO
from models.air import AirCooling
from models.case import Case
from models.cpu import CPU
from models.gpu import GPU
from models.mb import MotherBoard
from models.power import PowerSupply
from models.ram import Ram
from models.ssd import SSD
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
    files_info = [("./hardware_data/aio.txt", 2), ("./hardware_data/air.txt", 3), ("./hardware_data/case.txt", 6),
                  ("./hardware_data/cpu.txt", 6), ("./hardware_data/gpu.txt", 3), ("./hardware_data/mb.txt", 5),
                  ("./hardware_data/power_supply.txt", 6), ("./hardware_data/ram.txt", 5),
                  ("./hardware_data/ssd.txt", 4)]

    hardware_list = []

    for file_info in files_info:
        with open(file_info[0], "r") as txt_file:
            with open(f"./collected_info/{file_info[0].split('/')[2].split('.')[0]}.json", 'r') as json_file:
                txt_data = txt_file.readlines()
                json_data = json.load(json_file)
                match file_info[0]:
                    case "./hardware_data/aio.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 0
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            fans_count = int(info[1])

                            hardware_list.append(AIO(product_type, model, price, link, fans_count))

                    case "./hardware_data/air.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 1
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            tdp = int(info[1])
                            height = int(info[2])

                            hardware_list.append(AirCooling(product_type, model, price, link, tdp, height))

                    case "./hardware_data/case.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 2
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            mb_format = info[1]
                            ps_length = int(info[2])
                            gpu_length = int(info[3])
                            air_height = int(info[4])
                            aio_fans_count = int(info[5])

                            hardware_list.append(
                                Case(product_type, model, price, link,
                                     mb_format, ps_length, gpu_length, air_height, aio_fans_count))

                    case "./hardware_data/cpu.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 3
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            manufacturer = info[1]
                            ddr5 = bool(info[2])
                            integrated_graphics = bool(info[3])
                            tdp = int(info[4])
                            socket = info[5]

                            hardware_list.append(
                                CPU(product_type, model, price, link,
                                    manufacturer, ddr5, integrated_graphics, tdp, socket))

                    case "./hardware_data/gpu.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 4
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            length = int(info[1])
                            required_ps = int(info[2])

                            hardware_list.append(
                                GPU(product_type, model, price, link,
                                    length, required_ps))

                    case "./hardware_data/mb.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 5
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            target_cpu = info[1]
                            mb_format = info[2]
                            socket = info[3]
                            ddr5 = bool(info[4])

                            hardware_list.append(
                                MotherBoard(product_type, model, price, link,
                                            target_cpu, mb_format, socket, ddr5))

                    case "./hardware_data/power_supply.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 6
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            wattage = int(info[1])
                            cert = info[2]
                            modular = bool(info[3])
                            length = int(info[4])

                            hardware_list.append(
                                PowerSupply(product_type, model, price, link,
                                            wattage, cert, modular, length))

                    case "./hardware_data/ram.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 7
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            ddr5 = bool(info[1])
                            frequency = int(info[2])
                            capacity = int(info[3])
                            count = int(info[4])

                            hardware_list.append(
                                Ram(product_type, model, price, link,
                                    ddr5, frequency, capacity, count))

                    case "./hardware_data/ssd.txt":
                        for line in txt_data:
                            info = line.split('@')

                            product_type = 8
                            model = info[0][2:]
                            price = 1e9
                            link = ''
                            collected = json_data[model]

                            if len(collected) == 0:
                                continue

                            for data_tuple in collected:
                                if 0.0 < data_tuple[0] < 200000.0:
                                    if data_tuple[0] < price:
                                        price = data_tuple[0]
                                        link = data_tuple[1]

                            if price == 1e9:
                                continue

                            capacity = int(info[1])
                            read_speed = int(info[2])
                            write_speed = int(info[3])

                            hardware_list.append(
                                SSD(product_type, model, price, link,
                                    capacity, read_speed, write_speed))

    return hardware_list


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
    # app.run(debug=True, port=3000, host="127.0.0.1")
    print(*process_collected_data(), sep='\n')
