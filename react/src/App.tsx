import { Container } from "@mui/material";
import "./App.css";
import MarketList from "./domain/markets/list";
import Search from "./shared/search";
import MarketProvider from "./stores/market/market";

function App() {
  return (
    <MarketProvider>
      <Container maxWidth="lg">
        <Search />
        <MarketList />
      </Container>
    </MarketProvider>
  );
}

export default App;
