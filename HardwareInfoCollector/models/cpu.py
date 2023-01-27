from models.hardware import *

class CPU(Hardware):
    Manufacturer: str
    RamType: int
    IntegratedGraphics: bool
    TDP: int
    Socket: str

