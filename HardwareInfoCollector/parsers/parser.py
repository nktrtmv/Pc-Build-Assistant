from selenium import webdriver
from bs4 import BeautifulSoup


class Parser:
    browser: webdriver

    def __init__(self, browser: webdriver):
        self.browser = browser

    def parse_cpu_list(self):
        cpu_data = dict()
        with open("./hardware/cpu.txt", 'r') as file:
            data = file.readlines()
            for line in data:
                ind = line.find("intel") if "intel" in line else line.find("amd")
                cpu_data[line.split("@")[0][ind:]] = []

            for site in range(6, 8):
                for line in data:
                    line = line[:-1]
                    ind = line.find("intel") if "intel" in line else line.find("amd")
                    cpu_data[line.split("@")[0][ind:]].append(self.get_product_price(line.split('@')[site]))

        print(cpu_data)

    def get_product_price(self, link: str) -> (int, str):
        self.browser.get(link)
        product = BeautifulSoup(self.browser.page_source, 'lxml')
        price_ind = str(product).find('"price":')
        near_price_string = str(product)[price_ind:(price_ind + 20)]
        price_string = near_price_string[8:near_price_string.find(",")]
        return price_string, link

