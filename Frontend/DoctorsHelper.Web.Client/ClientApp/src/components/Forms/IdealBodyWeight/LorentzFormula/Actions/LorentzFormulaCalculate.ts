import {IResult, IErrors} from "../../../../../common/Interfaces";
import {
    LorentzFormulaResponse,
    LorentzFormulaClient
} from "../../../../../apiClient/apiClient";
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function LorentzFormulaCalculate(height: number, isMan: boolean) {
    let res: IResult<LorentzFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new LorentzFormulaClient(getAuthClient());
        res.result = await client.calculateLorentzFormula(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}