from selenium import webdriver
from bs4 import BeautifulSoup
from selenium.webdriver.chrome.service import Service
from config import *
import time

# def get_chromedriver(user_agent):
#     chrome_options = webdriver.ChromeOptions()
#
#     if user_agent:
#         chrome_options.add_argument(f'--user-agent={user_agent}')
#
#     s = Service(
#         executable_path='chrome_drivers/chromedriver_mac_arm64/chromedriver'
#     )
#     driver = webdriver.Chrome(
#         service=s,
#         options=chrome_options
#     )
#
#     return driver


class Parser:
    browser: webdriver

    def parse_products(self, file: str, info_len: int) -> dict:
        """
            info_len for aio: 2;
            info_len for air: 3;
            info_len for case: 6;
            info_len for cpu: 6;
            info_len for gpu: 3;
            info_len for mb: 5;
            info_len for power_supply: 6;
            info_len for ram: 5;
            info_len for ssd: 4;
            :param file: file directory
            :param info_len: count of info sections in file
            :return: dictionary with parsed products
        """

        product_data = dict()
        with open(file, 'r') as f:
            data = f.readlines()
            for line in data:
                ind = line.find("*") + 2
                product_name = line.split("@")[0][ind:]
                product_data[product_name] = []
                line = line[:line.find("\n")]

                for site in range(info_len, len(line.split("@"))):
                    product_info = self.get_product_price(line.split('@')[site])
                    element_to_add = (100000000 if product_info[0] == '' else float(product_info[0]), product_info[1])
                    product_data[product_name].append(element_to_add)

        self.browser.close()
        self.browser.quit()

        return product_data

    def get_product_price(self, link: str) -> (int, str):
        self.browser.get(link)
        product = BeautifulSoup(self.browser.page_source, 'lxml')
        price_ind = str(product).find('"price":')
        near_price_string = str(product)[price_ind:(price_ind + 20)]
        price_string = near_price_string[8:near_price_string.find(",")]
        return price_string, link
