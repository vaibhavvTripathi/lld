namespace Models.Stock;
public enum TXN_TYPE {
    BUY,
    SELL
}

public enum ORDER_TYPE {
    MARKET,
    LIMIT
}

public enum EXCHANGE {
    NSE,
    BSE
}

public enum ORDER_STATUS {
    OPEN,
    PARTIALLY_DONE,
    DONE,
    CANCELLED
}