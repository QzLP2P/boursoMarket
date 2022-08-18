import { Container } from "@mui/system";
import { useMarkets } from "../../../stores/market/market";
import MarketItem from "../item";

const MarketList: React.FC<{}> = () => {
  const { markets } = useMarkets();

  return (
    <Container maxWidth="md">
      <h1>List</h1>
      {markets.slice(0, 5).map((market) => (
        <MarketItem key={market.codeISIN} market={market} />
      ))}
    </Container>
  );
};

export default MarketList;
