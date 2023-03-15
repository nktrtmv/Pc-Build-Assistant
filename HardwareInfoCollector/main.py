from parsers.parser import *
from selenium import webdriver

chrome = webdriver.Chrome()
parser = Parser(chrome)

parser.parse_product_list()

chrome.close()



