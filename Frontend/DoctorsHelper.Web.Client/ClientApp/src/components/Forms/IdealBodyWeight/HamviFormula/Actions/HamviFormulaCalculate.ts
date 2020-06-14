import {HamviFormulaResponse, HamviFormulaClient} from '../../../../../apiClient/apiClient';
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function HamviFormulaCalculate(height: number, isMan: boolean) {
    let res: IResult<HamviFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new HamviFormulaClient(getAuthClient());
        res.result = await client.calculate(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}