from models.hardware import *

class MotherBoard(Hardware):
    TargetCpu: str
    Format: str
    Socket: str
    RamType: int

    def __init__(self, target: str, model: str):
        super().__init__(model)
        self.TargetCpu = target

    def __str__(self):
        return f'{self.TargetCpu} {self.Model}'
