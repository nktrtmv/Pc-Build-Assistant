from selenium import webdriver
from selenium.webdriver.common.by import By
from bs4 import BeautifulSoup

class Parser:
    site_url: str
    search_input_xpath: str
    search_button_xpath: str
    product_html_class: str
    product_html_tag: str
    browser: webdriver

    def __init__(self, browser: webdriver):
        self.browser = browser

    def search_product(self, product_to_find):  # if is page -> True or page with links -> False, then soup or links
        self.browser.get(self.site_url)
        search_input = self.browser.find_element(By.XPATH, self.search_input_xpath)
        search_input.send_keys(product_to_find)
        search_button = self.browser.find_element(By.XPATH, self.search_button_xpath)
        search_button.click()
        soup = BeautifulSoup(self.browser.page_source, 'html.parser')
        products = soup.findAll(self.product_html_tag, class_=self.product_html_class)
        return False, [self.site_url + product.get('href') for product in products]
