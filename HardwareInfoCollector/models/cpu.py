from models.hardware import *


class CPU(Hardware):
    Manufacturer: str
    DDR5: bool
    IntegratedGraphics: bool
    TDP: int
    Socket: str

    def __init__(self, product_type: int, model: str, price: int, link: str,
                 manufacturer: str, ddr5: bool, integrated_graphics: bool, tdp: int, socket: str):
        super().__init__(product_type, model, price, link)
        self.Manufacturer = manufacturer
        self.DDR5 = ddr5
        self.IntegratedGraphics = integrated_graphics
        self.TDP = tdp
        self.Socket = socket
