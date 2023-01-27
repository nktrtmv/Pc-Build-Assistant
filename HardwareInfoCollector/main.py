from bs4 import BeautifulSoup
import requests
import lxml

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


# url = "https://www.regard.ru/product/373036/nakopitel-ssd-1tb-samsung-980-pro-mz-v8p1t0bw"
#
# headers = {'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.1 Safari/605.1.15'}
#
# page = requests.get(url, headers=headers)
#
# soup = BeautifulSoup(page.text, "lxml")
#
# quotes = soup.find_all('span', class_='PriceBlock_price__3hwFe')
#
# for quote in quotes:
#     print(quote.text)

def get_hardware_list():
    hardware = {'cpu': [],
                'case': [],
                'gpu': [],
                'air': [],
                'aio': [],
                'hdd': [],
                'ssd': [],
                'power': []}

    for hardware_part in hardware.keys():
        with open(f'./hardware/{hardware_part}.txt', 'r') as file:
            data = file.readlines()
            for line in data:
                line = line[:-1]
                f = line.find("*") + 2
                if f != 1:
                    line = line[f:]
                if hardware_part == 'cpu':
                    hardware[hardware_part].append(CPU(line))
                elif hardware_part == 'case':
                    hardware[hardware_part].append(Case(line))
                elif hardware_part == 'gpu':
                    hardware[hardware_part].append(GPU(line))
                elif hardware_part == 'air':
                    hardware[hardware_part].append(AirCooling(line))
                elif hardware_part == 'aio':
                    hardware[hardware_part].append(AIO(line))
                elif hardware_part == 'hdd':
                    hardware[hardware_part].append(HDD(line))
                elif hardware_part == 'ssd':
                    hardware[hardware_part].append(SSD(line))
                elif hardware_part == 'power':
                    hardware[hardware_part].append(PowerSupply(line))

    hardware['mb'] = []
    hardware['ram'] = []

    with open('./hardware/ram.txt', 'r') as ram_file:
        data = ram_file.readlines()
        flag = True
        for line in data:
            if line == '\n':
                flag = False
                continue
            if flag:
                hardware['ram'].append(Ram(4, line[2:-1]))
            else:
                hardware['ram'].append(Ram(5, line[2:-1]))

        with open('./hardware/mb.txt', 'r') as mb_file:
            data = mb_file.readlines()
            current = ''
            for line in data:
                f = line.find('cpu')
                if f != -1:
                    current = line[f + 6:-1]
                    continue

                hardware['mb'].append(MotherBoard(current, line[2:-1]))
    return hardware


hardware_list = get_hardware_list()
for i in hardware_list.keys():
    for j in hardware_list[i]:
        print(i,  j)
