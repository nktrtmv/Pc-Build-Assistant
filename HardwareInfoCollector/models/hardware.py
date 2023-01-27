class Hardware:
    Model: str
    Link: str
    Price: float

    def __init__(self, model: str):
        self.Model = model

    def __str__(self):
        return self.Model