from models.hardware import *

class Case(Hardware):
    PowerSupplyFormat: str
    MotherBoardFormat: str
    MaxPowerLength: int
    MaxGpuLength: int
    MaxAirHeight: int
    MaxAioSize: int
