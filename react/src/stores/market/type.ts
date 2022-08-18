export type MarketType = {
  codeSupport: string;
  libelleSupport: string;
  codeISIN: string;
  url: string;
};

export type ContextProviderType = {
  markets: MarketType[];
  setMarkets: React.Dispatch<React.SetStateAction<MarketType[]>>;
};
