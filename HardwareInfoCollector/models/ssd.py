from models.hardware import *


class SSD(Hardware):
    Capacity: int
    ReadSpeed: int
    WriteSpeed: int

    def __init__(self, product_type: int, model: str, price: int, link: str,
                 capacity: int, read_speed: int, write_speed: int):
        super().__init__(product_type, model, price, link)
        self.Capacity = capacity
        self.ReadSpeed = read_speed
        self.WriteSpeed = write_speed
