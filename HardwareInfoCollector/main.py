from models.hardware import *
from hardware.HardwareList import *

from parsers.parser import *
from parsers.dns import *
from parsers.regard import *
from selenium import webdriver

# hardware = get_hardware_list()

chrome = webdriver.Chrome()
dns = Dns(chrome)

with open("./hardware/cpu.txt", 'r') as file:
    data = file.readlines()
    for line in data:
        print(dns.get_product_price(line.split('@')[0][2:]))

chrome.close()


