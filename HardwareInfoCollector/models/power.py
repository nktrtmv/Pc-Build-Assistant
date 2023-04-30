from models.hardware import *


class PowerSupply(Hardware):
    Wattage: int
    Certification: str
    IsModular: bool
    Length: int

    def __init__(self, product_type: int, model: str, price: int, link: str,
                 wattage: int, certification: str, is_modular: bool, length: int):
        super().__init__(product_type, model, price, link)
        self.Wattage = wattage
        self.Certification = certification
        self.IsModular = is_modular
        self.Length = length

    def __str__(self):
        return f'{self.ProductType} {self.Model} {self.Price} {self.Link} {self.Wattage} ' \
               f'{self.Certification} {self.IsModular} {self.Length}'
