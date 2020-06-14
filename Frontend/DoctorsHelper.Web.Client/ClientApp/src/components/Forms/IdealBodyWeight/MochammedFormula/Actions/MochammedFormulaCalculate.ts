import {
    MochammedFormulaResponse,
    MochammedFormulaClient
} from '../../../../../apiClient/apiClient';
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function MochammedFormulaCalculate(height: number) {
    let res: IResult<MochammedFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new MochammedFormulaClient(getAuthClient());
        res.result = await client.calculate(height);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}