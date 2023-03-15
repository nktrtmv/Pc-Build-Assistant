from selenium import webdriver
from bs4 import BeautifulSoup


class Parser:
    browser: webdriver
    parsed_product_data_for_test = {
        'intel core i3 12100 oem': [
            (10199.0,
             'https://www.dns-shop.ru/product/ebd4f363fcc7ed20/processor-intel-core-i3-12100-oem/'),
            (10230.0,
             'https://www.regard.ru/product/425544/processor-intel-core-i3-12100-oem'),
            (100000000,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/intel/protsessor_intel_core_i3_12100_lga1700_oem_cm8071504651012-3030332.html')],
        'intel core i5 12400f': [
            (14399.0,
             'https://www.dns-shop.ru/product/0a2114a7fcc9ed20/processor-intel-core-i5-12400f-oem/'),
            (14030.0,
             'https://www.regard.ru/product/421881/processor-intel-core-i5-12400f-oem'),
            (14290.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/intel/protsessor_intel_core_i5_12400f_lga1700_oem_cm8071504650609-2968501.html')],
        'intel core i5 12400 oem': [
            (14499.0,
             'https://www.dns-shop.ru/product/d3c6a3f806feed20/processor-intel-core-i5-12400-oem/'),
            (15520.0,
             'https://www.regard.ru/product/421879/processor-intel-core-i5-12400-oem'),
            (14790.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/intel/protsessor_intel_core_i5_12400_lga1700_oem_cm8071504555317-2968506.html')],
        'intel core i5 12600kf': [
            (22499.0,
             'https://www.dns-shop.ru/product/ee41c253fb7bed20/processor-intel-core-i5-12600kf-oem/'),
            (21720.0,
             'https://www.regard.ru/product/412304/processor-intel-core-i5-12600kf-oem'),
            (22490.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/intel/protsessor_intel_core_i5_12600kf_lga1700_oem_cm8071504555228-2868584.html')],
        'intel core i5 13600kf': [
            (28299.0,
             'https://www.dns-shop.ru/product/9d0e9a293f90ed20/processor-intel-core-i5-13600kf-oem/'),
            (29770.0,
             'https://www.regard.ru/product/457773/processor-intel-core-i5-13600kf-oem'),
            (29990.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/intel/protsessor_intel_core_i5_13600kf_lga1700_oem_cm8071504821006-3408167.html')],
        'intel core i7 13700kf': [
            (38299.0,
             'https://www.dns-shop.ru/product/885e95283f99ed20/processor-intel-core-i7-13700kf-oem/'),
            (37070.0,
             'https://www.regard.ru/product/458962/processor-intel-core-i7-13700kf-oem'),
            (39490.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/intel/protsessor_intel_core_i7_13700kf_lga1700_oem_cm8071504820706-3408168.html')],
        'intel core i9 13900kf': [
            (56299.0,
             'https://www.dns-shop.ru/product/5d2dd9f13fa0ed20/processor-intel-core-i9-13900kf-oem/'),
            (55830.0,
             'https://www.regard.ru/product/460675/processor-intel-core-i9-13900kf-oem'),
            (57590.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/intel/protsessor_intel_core_i9_13900kf_lga1700_oem_cm8071505094012-3445005.html')],
        'amd ryzen 7 5800x': [
            (21999.0,
             'https://www.dns-shop.ru/product/4e48fbd4fb77ed20/processor-amd-ryzen-7-5800x-oem/'),
            (22230.0,
             'https://www.regard.ru/product/370866/processor-amd-ryzen-7-5800x-oem'),
            (22190.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/amd/protsessor_amd_ryzen_7_5800x_am4_oem_100_000000063-2369108.html')],
        'amd ryzen 5 7600x': [
            (22999.0,
             'https://www.dns-shop.ru/product/5825b93b38afed20/processor-amd-ryzen-5-7600x-oem/'),
            (22170.0,
             'https://www.regard.ru/product/419163/processor-amd-ryzen-5-7600x-oem'),
            (22690.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/amd/protsessor_amd_ryzen_5_7600x_am5_oem_100_000000593-3375392.html')],
        'amd ryzen 7 7700x': [
            (30799.0,
             'https://www.dns-shop.ru/product/75bdc52138b2ed20/processor-amd-ryzen-7-7700x-oem/'),
            (31080.0,
             'https://www.regard.ru/product/419168/processor-amd-ryzen-7-7700x-oem'),
            (30790.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/amd/protsessor_amd_ryzen_7_7700x_am5_oem_100_000000591-3408174.html')],
        'amd ryzen 9 7900x': [
            (41799.0,
             'https://www.dns-shop.ru/product/7a2387593941ed20/processor-amd-ryzen-9-7900x-oem/'),
            (42720.0,
             'https://www.regard.ru/product/419169/processor-amd-ryzen-9-7900x-oem'),
            (42490.0,
             'https://www.onlinetrade.ru/catalogue/protsessory-c342/amd/protsessor_amd_ryzen_9_7900x_am5_oem_100_000000589-3408173.html')]}

    def __init__(self, browser: webdriver):
        self.browser = browser

    def parse_product_list(self):
        # product_data = dict()
        # with open("./hardware/cpu.txt", 'r') as file:
        #     data = file.readlines()
        #     for line in data:
        #         ind = line.find("intel") if "intel" in line else line.find("amd")
        #         product_name = line.split("@")[0][ind:]
        #         product_data[product_name] = []
        #         line = line[:line.find("\n")]
        #
        #         for site in range(6, len(line.split("@"))):
        #             product_info = self.get_product_price(line.split('@')[site])
        #             element_to_add = (100000000 if product_info[0] == '' else float(product_info[0]), product_info[1])
        #             product_data[product_name].append(element_to_add)

        product_data = self.parsed_product_data_for_test

        for info in product_data.items():
            name = info[0]
            price_and_link = min(info[1], key=lambda i: i[0])
            print(name, price_and_link)

        print(product_data)

    def get_product_price(self, link: str) -> (int, str):
        self.browser.get(link)
        product = BeautifulSoup(self.browser.page_source, 'lxml')
        price_ind = str(product).find('"price":')
        near_price_string = str(product)[price_ind:(price_ind + 20)]
        price_string = near_price_string[8:near_price_string.find(",")]
        return price_string, link
