from selenium import webdriver
from selenium.webdriver.common.by import By
from bs4 import BeautifulSoup


class Parser:
    site_url: str
    product_to_find: str
    search_input_xpath: str
    search_button_xpath: str
    product_html_class: str
    browser: webdriver

    def __init__(self, site_url: str, product_to_find: str, search_input_xpath: str, search_button_xpath: str,
                 product_html_class: str):
        self.product_to_find = product_to_find
        self.site_url = site_url
        self.search_input_xpath = search_input_xpath
        self.search_button_xpath = search_button_xpath
        self.product_html_class = product_html_class
        self.browser = webdriver.Chrome()

    def get_links(self):
        self.browser.get(self.site_url)
        search_input = self.browser.find_element(By.XPATH, self.search_input_xpath)
        search_input.send_keys(self.product_to_find)
        search_button = self.browser.find_element(By.XPATH, self.search_button_xpath)
        search_button.click()
        soup = BeautifulSoup(self.browser.page_source, 'html.parser')
        products = soup.findAll('a', class_=self.product_html_class)
        self.browser.close()
        return [self.site_url + product.get('href') for product in products]

    def parse_aio_links(self):
        return None

    def parse_air_links(self):
        return None

    def parse_case_links(self):
        return None

    def parse_cpu_links(self):
        return None

    def parse_gpu_links(self):
        return None

    def parse_cpu_links(self):
        return None

    def parse_hdd_links(self):
        return None

    def parse_mb_links(self):
        return None

    def parse_power_links(self):
        return None

    def parse_ram_links(self):
        return None

    def parse_ssd_links(self):
        return None
