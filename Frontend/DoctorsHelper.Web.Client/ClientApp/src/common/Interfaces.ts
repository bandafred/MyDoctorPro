export interface IResult<T> {
  result?: T;
  error?: IErrors;
}

export interface IErrors {
  errors: string[];
}

export interface IGeneralResult {
  nameCalculator: string;
  result: string;
}

export interface ISelectNameValue{
  name: string;
  value: number;
}