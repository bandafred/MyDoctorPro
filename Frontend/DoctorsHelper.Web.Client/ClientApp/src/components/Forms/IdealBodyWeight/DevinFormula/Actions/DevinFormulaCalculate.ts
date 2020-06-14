import {IResult, IErrors} from "../../../../../common/Interfaces";
import {DevinFormulaResponse, DevinFormulaClient} from "../../../../../apiClient/apiClient";
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function DevinFormulaCalculate(height: number, isMan: boolean) {
    let res: IResult<DevinFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new DevinFormulaClient(getAuthClient());
        res.result = await client.calculate(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}
