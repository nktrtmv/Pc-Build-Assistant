from models.hardware import *

class AirCooling(Hardware):
    TDP: int
    Height: int

    def __init__(self, product_type: int, model: str, price: int, link: str, tdp, height):
        super().__init__(product_type, model, price, link)
        self.TDP = tdp
        self.Height = height

    def __str__(self):
        return f'{self.ProductType} {self.Model} {self.Price} {self.Link} {self.TDP} {self.Height}'
    