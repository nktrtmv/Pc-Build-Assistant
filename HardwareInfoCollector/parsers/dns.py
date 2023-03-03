import time
from parsers.parser import *
from models.cpu import *
import lxml


class Dns(Parser):
    site_url = 'https://www.dns-shop.ru/'
    search_input_xpath = '//*[@id="header-search"]/div/div[2]/div[1]/input'
    search_button_xpath = '//*[@id="header-search"]/div/div[2]/div[1]/div[2]/span[2]'
    product_html_class = 'catalog-product__name ui-link ui-link_black'
    product_html_tag = 'a'

    def get_product_price(self, product_to_find: str) -> (int, str):
        while True:
            time.sleep(5)
            links = self.search_product(product_to_find)
            if links is None:
                return None
            elif links[0]:
                price = self.parse_product_page(100000000)
                if price is None:
                    return None
                elif price[0] == 1:
                    return price[1], 'null'
                elif price[0] == 0:
                    return 0, 'not available'

            available = False
            not_available = False
            min_price = 1000000
            min_index = -1
            for i, link in enumerate(links[1]):
                self.browser.get(link)
                temp = self.parse_product_page(min_price)

                if temp is None:
                    return None
                elif temp[0] == 1:
                    available = True
                    if temp[1] < min_price:
                        min_price = temp[1]
                        min_index = i
                elif temp[0] == 0:
                    available = False

            if available:
                return min_price, links[min_index]
            if not_available:
                return -1, ''

    def parse_product_page(self, min_price) -> (int, int):
        product = BeautifulSoup(self.browser.page_source, 'lxml')
        str_product = str(product)
        if 'В наличии:' in str_product or 'магазинах' in str_product or 'Доставим' in str_product \
                or 'class="order-avail-wrap"' in str_product or 'class="available"' in str_product:
            s_p = str(product)
            start = s_p.find('"product-buy__price">') + 21
            price = s_p[start:start + 9]
            price_syms = [sym for sym in price if (sym in '1234567890')]
            price = ''
            for sym in price_syms:
                price += sym
            price = int(price)
            return 1, min(min_price, price)
        elif 'Уведомить' in str_product or 'order-avail-wrap_not-avail' in str_product \
                or 'Товара нет в наличии' in str_product:
            return 0, min_price
        else:
            print('product parse error')
            # print(str_product)
            return None
