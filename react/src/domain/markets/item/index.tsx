import { Container } from "@mui/system";
import { MarketItemType } from "./type";

const MarketItem: React.FC<MarketItemType> = ({ market }) => {
  console.info(`trying to open : ${market.url}`);

  fetch(market.url, {
    mode: "no-cors",
    headers: {
      "x-content-security-policy":
        "frame-ancestors 'self' *.boursorama-banque.com *.boursorama.com",
    },
  })
    .then((res) => {
      // debugger;
      res.text();
    })
    .then((body) => {
      console.info(body);
    })
    .catch((e) => {
      console.error(e);
    });

  return (
    <Container maxWidth="md">
      <h1>{market.libelleSupport}</h1>
      <Container maxWidth="xs">
        <iframe
          src={market.url}
          // sandbox="allow-same-origin allow-scripts allow-popups allow-forms"
        ></iframe>
        {/* <div
          dangerouslySetInnerHTML={{ __html: `<iframe src='${market.url}' />` }}
        /> */}
      </Container>
    </Container>
  );
};

export default MarketItem;
