from models.hardware import *
from hardware.HardwareList import *

from parsers.parser import *
from parsers.dns import *
from selenium import webdriver

# hardware = get_hardware_list()

browser = webdriver.Chrome()

parser = Dns(browser)

cpu_to_parse = "amd ryzen 7700x"
processors = parser.parse_cpu_links(parser.get_links(cpu_to_parse), cpu_to_parse)
for cpu in processors:
    print(cpu)
browser.close()


