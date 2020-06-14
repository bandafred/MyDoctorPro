import {
    RobinsonFormulaResponse,
    RobinsonFormulaClient
} from '../../../../../apiClient/apiClient';
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function RobinsonFormulaCalculate(height: number, isMan: boolean) {
    let res: IResult<RobinsonFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new RobinsonFormulaClient(getAuthClient());
        res.result = await client.calculate(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}