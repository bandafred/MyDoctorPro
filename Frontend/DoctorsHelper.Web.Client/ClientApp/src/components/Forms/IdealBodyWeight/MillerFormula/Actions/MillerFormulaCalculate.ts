import {IErrors, IResult} from '../../../../../common/Interfaces';
import {MillerFormulaClient, MillerFormulaResponse} from '../../../../../apiClient/apiClient';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";


export async function MillerFormulaCalculate(height: number, isMan: boolean) {
    let res: IResult<MillerFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new MillerFormulaClient(getAuthClient());
        res.result = await client.calculate(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}