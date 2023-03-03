class Hardware:
    Model: str
    Link: str
    Price: str

    def __init__(self, model: str):
        self.Model = model

    def __str__(self):
        return self.Model
# print()
#                 find = product.find('div', class_='product-buy__price')
#                 print(find)
#                 price_str = str(product.find('div', class_='product-buy__price'))
#
#                 print(price_str)
#
#                 price = ''
#                 flag = False
#                 for i, sym in enumerate(price_str):
#                     if flag:
#                         if sym == '₽':
#                             break
#                         price += sym
#                     elif sym == '>':
#                         flag = True
#                         continue
#
#                 print(price)