from models.hardware import *
from bs4 import BeautifulSoup
import requests
import lxml

class CPU(Hardware):
    Manufacturer: str
    RamType: int
    IntegratedGraphics: bool
    TDP: int
    Socket: str
