from models.hardware import *


class GPU(Hardware):
    Length: int
    RequiredPowerSupplyWattage: int

    def __init__(self, product_type: int, model: str, price: int, link: str,
                 length: int, required_power_supply_wattage: int):
        super().__init__(product_type, model, price, link)
        self.Length = length
        self.RequiredPowerSupplyWattage = required_power_supply_wattage

    def __str__(self):
        return f'{self.ProductType} {self.Model} {self.Price} {self.Link} {self.Length} ' \
               f'{self.RequiredPowerSupplyWattage}'
