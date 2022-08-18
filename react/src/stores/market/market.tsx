import { createContext, useContext, useState } from "react";
import marketsData from "../../data/data.js";

import { ContextProviderType, MarketType } from "./type";

const defaultValue: ContextProviderType = {
  markets: [],
  setMarkets: () => {
    throw new Error("setMarkets is not implemented");
  },
};

const MarketContext = createContext<ContextProviderType>(defaultValue);

const MarketProvider: React.FC<any> = ({ children }) => {
  const [markets, setMarkets] = useState<MarketType[]>(marketsData);

  return (
    <MarketContext.Provider value={{ markets, setMarkets }}>
      {children}
    </MarketContext.Provider>
  );
};

export const useMarkets = () => useContext(MarketContext);

export default MarketProvider;
