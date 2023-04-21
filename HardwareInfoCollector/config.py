import random


class Configuration:
    PROXY_USER = 'yBFGM8'
    PROXY_PASS = 'EeUqLa'

    PROXY_HOST_1 = '194.67.201.235'
    PROXY_PORT_1 = 9262

    PROXY_HOST_2 = '149.126.222.221'
    PROXY_PORT_2 = 9447

    PROXY_HOST_3 = '193.233.62.94'
    PROXY_PORT_3 = 9252

    manifest_json_1 = """
    {
        "version": "1.0.0",
        "manifest_version": 2,
        "name": "Chrome Proxy",
        "permissions": [
            "proxy",
            "tabs",
            "unlimitedStorage",
            "storage",
            "<all_urls>",
            "webRequest",
            "webRequestBlocking"
        ],
        "background": {
            "scripts": ["background.js"]
        },
        "minimum_chrome_version":"76.0.0"
    }
    """

    manifest_json_2 = """
        {
            "version": "1.0.0",
            "manifest_version": 2,
            "name": "Chrome Proxy",
            "permissions": [
                "proxy",
                "tabs",
                "unlimitedStorage",
                "storage",
                "<all_urls>",
                "webRequest",
                "webRequestBlocking"
            ],
            "background": {
                "scripts": ["background.js"]
            },
            "minimum_chrome_version":"76.0.0"
        }
        """

    manifest_json_3 = """
        {
            "version": "1.0.0",
            "manifest_version": 2,
            "name": "Chrome Proxy",
            "permissions": [
                "proxy",
                "tabs",
                "unlimitedStorage",
                "storage",
                "<all_urls>",
                "webRequest",
                "webRequestBlocking"
            ],
            "background": {
                "scripts": ["background.js"]
            },
            "minimum_chrome_version":"76.0.0"
        }
        """

    background_js_1 = """
    let config = {
            mode: "fixed_servers",
            rules: {
            singleProxy: {
                scheme: "http",
                host: "%s",
                port: parseInt(%s)
            },
            bypassList: ["localhost"]
            }
        };
    chrome.proxy.settings.set({value: config, scope: "regular"}, function() {});
    function callbackFn(details) {
        return {
            authCredentials: {
                username: "%s",
                password: "%s"
            }
        };
    }
    chrome.webRequest.onAuthRequired.addListener(
                callbackFn,
                {urls: ["<all_urls>"]},
                ['blocking']
    );
    """ % (PROXY_HOST_1, PROXY_PORT_1, PROXY_USER, PROXY_PASS)

    background_js_2 = """
        let config = {
                mode: "fixed_servers",
                rules: {
                singleProxy: {
                    scheme: "http",
                    host: "%s",
                    port: parseInt(%s)
                },
                bypassList: ["localhost"]
                }
            };
        chrome.proxy.settings.set({value: config, scope: "regular"}, function() {});
        function callbackFn(details) {
            return {
                authCredentials: {
                    username: "%s",
                    password: "%s"
                }
            };
        }
        chrome.webRequest.onAuthRequired.addListener(
                    callbackFn,
                    {urls: ["<all_urls>"]},
                    ['blocking']
        );
        """ % (PROXY_HOST_2, PROXY_PORT_2, PROXY_USER, PROXY_PASS)

    background_js_3 = """
        let config = {
                mode: "fixed_servers",
                rules: {
                singleProxy: {
                    scheme: "http",
                    host: "%s",
                    port: parseInt(%s)
                },
                bypassList: ["localhost"]
                }
            };
        chrome.proxy.settings.set({value: config, scope: "regular"}, function() {});
        function callbackFn(details) {
            return {
                authCredentials: {
                    username: "%s",
                    password: "%s"
                }
            };
        }
        chrome.webRequest.onAuthRequired.addListener(
                    callbackFn,
                    {urls: ["<all_urls>"]},
                    ['blocking']
        );
        """ % (PROXY_HOST_3, PROXY_PORT_3, PROXY_USER, PROXY_PASS)

    user_agents = [
        "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 13_0_0; en-US; Valve Steam GameOverlay/1676336721; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36",
        "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 13_2_1; en-US; Valve Steam Tenfoot/1676336721; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36",
        "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 13_2_1; en-US; Valve Steam GameOverlay/1676336721; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36",
        "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 13_2_0; en-US; Valve Steam GameOverlay/1675222618; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.9; rv:43.0) Gecko/20100101 Firefox/43.0 SeaMonkey/8650",
        "Mozilla/5.0 (Macintosh; PPC Mac OS X 10.4; rv:38.0) Gecko/20100101 Firefox/38.0 TenFourFox/7450",
        "Mozilla/5.0 (Macintosh; PPC Mac OS X 10.4; FPR12; rv:45.0) Gecko/20100101 Firefox/45.0 TenFourFox/7450",
        "Mozilla/5.0 (Macintosh; U; PowerPC Mac OS X 10_5_8; en-US) AppleWebKit/533.21.1+(KHTML, like Gecko, Safari/533.19.4) Version/6.0 OmniWeb/630.0",
        "Mozilla/5.0 (Macintosh; U; PowerPC Mac OS X 10_5_8; en-US) AppleWebKit/533.21.1 (KHTML, like Gecko, Safari/533.19.4) Version/6.0 OmniWeb/628.0",
        "Google Chrome/111.0.5563.64 Mac OS X",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 13.2; rv:110.0) Gecko/20100101 Firefox/111.0",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5561.221 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_2_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36 Edg/111.0.1661.44",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5523.195 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.11; rv:109.0) Gecko/20100101 Firefox/111.0",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_2_1) AppleWebKit/605.1.15 (KHTML, like Gecko) Chrome/111.0.5563.64 Safari/605.1.15",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 Edg/111.0.1661.51",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5530.201 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5492.203 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5558.213 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5364.215 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5413.155 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5394.100 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5364.154 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5381.139 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5412.212 Safari/537.36"]

    def get_random_user_agent(self):
        return self.user_agents[random.randint(0, len(self.user_agents) - 1)]
