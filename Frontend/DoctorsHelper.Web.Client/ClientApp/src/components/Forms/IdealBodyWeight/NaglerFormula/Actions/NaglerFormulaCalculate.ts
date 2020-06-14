import {NaglerFormulaClient, NaglerFormulaResponse} from '../../../../../apiClient/apiClient';
import {IErrors, IResult} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function NaglerFormulaCalculate(height: number, isMan: boolean) {
    let res: IResult<NaglerFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new NaglerFormulaClient(getAuthClient());
        res.result = await client.calculate(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}