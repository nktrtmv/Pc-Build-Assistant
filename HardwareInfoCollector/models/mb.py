from models.hardware import *

class MotherBoard(Hardware):
    TargetCpu: str
    BoardFormat: str
    Socket: str
    DDR5: bool

    def __init__(self, model: str, product_type: int, price: int, link: str,
                 target_cpu: str, board_format: str, socket: str, ddr5: bool):
        super().__init__(product_type, model, price, link)
        self.TargetCpu = target_cpu
        self.BoardFormat = board_format
        self.Socket = socket
        self.DDR5 = ddr5
