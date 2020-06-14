import {
    MonnerotFormulaResponse,
    MonnerotFormulaClient
} from '../../../../../apiClient/apiClient';
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function MonnerotFormulaCalculate(
    height: number,
    wristLength: number
) {
    let res: IResult<MonnerotFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new MonnerotFormulaClient(getAuthClient());
        res.result = await client.calculate(height, wristLength);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}
  