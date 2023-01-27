from models.hardware import *

class PowerSupply(Hardware):
    Wattage: int
    FormFactor: str
    Certification: str
    IsModular: bool

