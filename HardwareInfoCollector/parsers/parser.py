from selenium import webdriver
from selenium.webdriver.common.by import By
from bs4 import BeautifulSoup

class Parser:
    site_url: str
    search_input_xpath: str
    search_button_xpath: str
    product_html_class: str
    browser: webdriver

    def __init__(self, browser: webdriver):
        self.browser = browser

    def get_links(self, product_to_find):
        self.browser.get(self.site_url)
        search_input = self.browser.find_element(By.XPATH, self.search_input_xpath)
        search_input.send_keys(product_to_find)
        search_button = self.browser.find_element(By.XPATH, self.search_button_xpath)
        search_button.click()
        soup = BeautifulSoup(self.browser.page_source, 'html.parser')
        products = soup.findAll('a', class_=self.product_html_class)
        return [self.site_url + product.get('href') for product in products]
