from models.hardware import *

class Ram(Hardware):
    DDRType: int
    Frequency: int
    Capacity: int
    Count: int

    def __init__(self, ram_type: int, model: str):
        super().__init__(model)
        self.DDRType = ram_type

    def __str__(self):
        return str(self.DDRType) + " " + self.Model



