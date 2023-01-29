from models.aio import AIO
from models.air import AirCooling
from models.case import Case
from models.cpu import CPU
from models.gpu import GPU
from models.hdd import HDD
from models.mb import MotherBoard
from models.power import PowerSupply
from models.ram import Ram
from models.ssd import SSD

# from hardware import HardwareList
# hardware = HardwareList.get_hardware_list()


import Parser

parser = Parser.Parser('https://www.dns-shop.ru/', "intel core i5 13600",
                               '//*[@id="header-search"]/div/div[2]/div[1]/input',
                               '//*[@id="header-search"]/div/div[2]/div[1]/div[2]/span[2]',
                               'catalog-product__name ui-link ui-link_black')

print(parser.get_links())
