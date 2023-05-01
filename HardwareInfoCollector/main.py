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
from flask import Flask, make_response
import psycopg2

conn = psycopg2.connect(
    dbname="hardware",
    user="nktrtmv",
    password="hardware_db_password",
    host="localhost",
    port="5432"
)


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
                            ddr5 = int(info[2]) == 1
                            integrated_graphics = int(info[3]) == 1
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
                            ddr5 = int(info[4]) == 5

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
                            modular = int(info[3]) == 1
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

                            ddr5 = int(info[1]) == 5
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


def update_database(hardware_list: []):
    # Start a new transaction
    conn.autocommit = False
    cursor = conn.cursor()

    try:
        # Loop over the list of products
        for product in hardware_list:
            # Check if the model already exists in the hardware table
            cursor.execute("SELECT * FROM hardware WHERE model = %s", (product.Model,))
            result = cursor.fetchone()

            if result:
                # Update the info of the existing hardware object
                cursor.execute("UPDATE hardware SET price = %s, link = %s WHERE model = %s",
                               (product.Price, product.Link, product.Model)
                               )
            else:
                # Add a new hardware object
                cursor.execute(
                    "INSERT INTO hardware (product_type, model, price, link) VALUES (%s, %s, %s, %s) returning id",
                    (product.ProductType, product.Model, product.Price, product.Link)
                )

                hardware_id = cursor.fetchone()[0]

                if isinstance(product, AIO):
                    cursor.execute(
                        "INSERT INTO aio (hardware_id, fans_count) VALUES (%s, %s)",
                        (hardware_id, product.FansCount)
                    )
                elif isinstance(product, AirCooling):
                    cursor.execute(
                        "INSERT INTO air (hardware_id, tdp, height) VALUES (%s, %s, %s)",
                        (hardware_id, product.TDP, product.Height)
                    )
                elif isinstance(product, Case):
                    cursor.execute(
                        "INSERT INTO pc_case (hardware_id, motherboard_format, max_power_supply_length, max_gpu_length, max_air_height, max_aio_fans_count) VALUES (%s, %s, %s, %s, %s, %s)",
                        (hardware_id, product.MotherBoardFormat, product.MaxPowerSupplyLength, product.MaxGpuLength,
                         product.MaxAirHeight, product.MaxAioFansCount)
                    )
                elif isinstance(product, CPU):
                    cursor.execute(
                        "INSERT INTO cpu (hardware_id, manufacturer, ddr5, integrated_graphics, tdp, socket) VALUES (%s, %s, %s, %s, %s, %s)",
                        (hardware_id, product.Manufacturer, product.DDR5, product.IntegratedGraphics, product.TDP,
                         product.Socket)
                    )
                elif isinstance(product, GPU):
                    cursor.execute(
                        "INSERT INTO gpu (hardware_id, gpu_length, required_power_supply_wattage) VALUES (%s, %s, %s)",
                        (hardware_id, product.Length, product.RequiredPowerSupplyWattage)
                    )
                elif isinstance(product, MotherBoard):
                    cursor.execute(
                        "INSERT INTO motherboard (hardware_id, target_cpu, format, socket, ddr5) VALUES (%s, %s, %s, %s, %s)",
                        (hardware_id, product.TargetCpu, product.BoardFormat, product.Socket, product.DDR5)
                    )
                elif isinstance(product, PowerSupply):
                    cursor.execute(
                        "INSERT INTO power_supply (hardware_id, wattage, certification, is_modular, power_supply_length) VALUES (%s, %s, %s, %s, %s)",
                        (hardware_id, product.Wattage, product.Certification, product.IsModular, product.Length)
                    )
                elif isinstance(product, Ram):
                    cursor.execute(
                        "INSERT INTO ram (hardware_id, ddr5, frequency, capacity, count) VALUES (%s, %s, %s, %s, %s)",
                        (hardware_id, product.DDR5, product.Frequency, product.Capacity, product.Count)
                    )
                elif isinstance(product, SSD):
                    cursor.execute(
                        "INSERT INTO ssd (hardware_id, capacity, read_speed, write_speed) VALUES (%s, %s, %s, %s)",
                        (hardware_id, product.Capacity, product.ReadSpeed, product.WriteSpeed)
                    )

        # Commit the transaction
        conn.commit()
        print("Transaction committed successfully")

    except Exception as error:
        # Rollback the transaction in case of any exception
        conn.rollback()
        print(error)
        print("Transaction rolled back")

    finally:
        # Close the cursor and connection
        cursor.close()
        conn.close()


app = Flask(__name__)


@app.route('/update-hardware-database')
def update_hardware_data():
    try:
        collect_data()

        hardware_list = process_collected_data()

        update_database(hardware_list)

        response = make_response("Success")
        response.status = 200

    except:
        response = make_response("Internal Server Error")
        response.status = 500

    return response


if __name__ == '__main__':
    app.run(debug=True, port=3000, host="127.0.0.1")
