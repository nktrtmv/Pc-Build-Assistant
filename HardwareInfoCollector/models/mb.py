from models.hardware import *

class MotherBoard(Hardware):
    TargetCpu: str
    BoardFormat: str
    Socket: str
    DDR5: bool

    def __init__(self, product_type: int, model: str, price: int, link: str,
                 target_cpu: str, board_format: str, socket: str, ddr5: bool):
        super().__init__(product_type, model, price, link)
        self.TargetCpu = target_cpu
        self.BoardFormat = board_format
        self.Socket = socket
        self.DDR5 = ddr5

    def __str__(self):
        return f'{self.ProductType} {self.Model} {self.Price} {self.Link} {self.TargetCpu} ' \
               f'{self.BoardFormat} {self.Socket} {self.DDR5}'
