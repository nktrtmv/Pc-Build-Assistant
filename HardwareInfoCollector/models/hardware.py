class Hardware:
    ProductType: int
    Model: str
    Price: int
    Link: str

    def __init__(self, product_type: int, model: str, price: int, link: str):
        self.ProductType = product_type
        self.Model = model
        self.Price = price
        self.Link = link
