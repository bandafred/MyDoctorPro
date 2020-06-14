import {CuperFormulaResponse, CuperFormulaClient} from "../../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function CuperFormulaCalculate(height: number, isMan: boolean) {
    let res: IResult<CuperFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new CuperFormulaClient(getAuthClient());
        res.result = await client.calculate(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}