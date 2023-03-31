from parsers.parser import *
from selenium import webdriver
import json

chrome = webdriver.Chrome()
parser = Parser(chrome)

files_info = [("./hardware_data/aio.txt", 2), ("./hardware_data/air.txt", 3), ("./hardware_data/case.txt", 6),
              ("./hardware_data/cpu.txt", 6), ("./hardware_data/gpu.txt", 3), ("./hardware_data/mb.txt", 5),
              ("./hardware_data/power_supply.txt", 6), ("./hardware_data/ram.txt", 5), ("./hardware_data/ssd.txt", 4)]

for file_info in files_info:
    parsed_data = parser.parse_products(*file_info)
    with open(f"./collected_info/{file_info[0].split('/')[2].split('.')[0]}.json", 'w') as file:
        json.dump(parsed_data, file)

chrome.close()
