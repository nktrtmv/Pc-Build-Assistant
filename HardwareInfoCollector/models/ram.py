from models.hardware import *


class Ram(Hardware):
    DDR5: bool
    Frequency: int
    Capacity: int
    Count: int

    def __init__(self, product_type: int, model: str, price: int, link: str,
                 ddr5: bool, frequency: int, capacity: int, count: int):
        super().__init__(product_type, model, price, link)
        self.DDR5 = ddr5
        self.Frequency = frequency
        self.Capacity = capacity
        self.Count = count
