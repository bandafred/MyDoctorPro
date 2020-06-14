import {
    SubstanceinSolutionResponse,
    SubstanceinSolutionClient
} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function SubstanceinSolutionResult(procent: number, volume: number) {
    let res: IResult<SubstanceinSolutionResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new SubstanceinSolutionClient(getAuthClient());
        res.result = await client.calculateSubstanceinSolution(procent, volume);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}