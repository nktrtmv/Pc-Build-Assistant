from models.hardware import *
from bs4 import BeautifulSoup
import requests
import lxml

class CPU(Hardware):
    Manufacturer: str
    DDR5: bool
    IntegratedGraphics: bool
    TDP: int
    Socket: str

    def __str__(self):
        return f"model - {self.Model}, link - {self.Link}, manufacturer - {self.Manufacturer}, socket - {self.Socket}, "
