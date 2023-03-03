import time
from parsers.parser import *
from models.cpu import *
import lxml

class Regard(Parser):
    site_url = 'https://www.regard.ru/'
    search_input_xpath = '//*[@id="searchInput"]'
    search_button_xpath = '//*[@id="__next"]/div/div[1]/div[1]/div/div/div/div[1]/div/div/div/div[1]/svg'
    product_html_class = 'CardText_link__2H3AZ link_black'
    product_html_tag = 'a'

    def get_product_price(self, product_to_find: str) -> (int, str):
        return None