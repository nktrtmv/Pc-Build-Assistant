from models.hardware import *

class AIO(Hardware):
    FansCount: int

    def __init__(self, product_type: int, model: str, price: int, link: str, fans_count: int):
        super().__init__(product_type, model, price, link)
        self.FansCount = fans_count

    def __str__(self):
        return f'{self.ProductType} {self.Model} {self.Price} {self.Link} {self.FansCount}'
