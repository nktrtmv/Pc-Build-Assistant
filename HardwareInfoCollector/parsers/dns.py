from parsers.parser import *
from bs4 import BeautifulSoup
from models.cpu import *


class Dns(Parser):
    site_url = 'https://www.dns-shop.ru/'
    search_input_xpath = '//*[@id="header-search"]/div/div[2]/div[1]/input'
    search_button_xpath = '//*[@id="header-search"]/div/div[2]/div[1]/div[2]/span[2]'
    product_html_class = 'catalog-product__name ui-link ui-link_black'

    def parse(self):
        # check if it is available
        # check price
        # get link
        return None

