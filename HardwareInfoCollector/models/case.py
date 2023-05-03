from models.hardware import *


class Case(Hardware):
    MotherBoardFormat: str
    MaxPowerSupplyLength: int
    MaxGpuLength: int
    MaxAirHeight: int
    MaxAioFansCount: int

    def __init__(self, product_type: int, model: str, price: int, link: str, motherboard_format: str,
                 max_power_supply_length: int, max_gpu_length: int, max_air_height: int, max_aio_fans_count: int):
        super().__init__(product_type, model, price, link)
        self.MotherBoardFormat = motherboard_format
        self.MaxPowerSupplyLength = max_power_supply_length
        self.MaxGpuLength = max_gpu_length
        self.MaxAirHeight = max_air_height
        self.MaxAioFansCount = max_aio_fans_count

    def __str__(self):
        return f'{self.ProductType} {self.Model} {self.Price} {self.Link} {self.MotherBoardFormat} ' \
               f'{self.MaxPowerSupplyLength} {self.MaxGpuLength} {self.MaxAirHeight} {self.MaxAioFansCount}'
