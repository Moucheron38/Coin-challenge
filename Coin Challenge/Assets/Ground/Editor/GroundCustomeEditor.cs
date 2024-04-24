using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(GroundEditor))]
public class GroundCustomeEditor : Editor
{
    GroundEditor _target;
    bool _needSave, deleted;
    GUIStyle _style;
    PrefabInstanceStatus _type;

    private void OnEnable()
    {
        _target = (GroundEditor)target;

        //if (PrefabUtility.GetPrefabInstanceStatus(_target.gameObject) ==  PrefabInstanceStatus.) return;

        _type = PrefabUtility.GetPrefabInstanceStatus(_target.gameObject);

        if (_type == PrefabInstanceStatus.NotAPrefab) return;
        if (Application.isPlaying) return;

        if (_target._instanceID == 0 || _target._instanceID != _target.gameObject.GetInstanceID())
        {
            _target._instanceID = _target.gameObject.GetInstanceID();
            CreateMesh();
            SaveMesh();

        }

        if (_target._mesh == null)
        {
            CreateMesh();
            SaveMesh();
        }
    }

    private void OnDisable()
    {
        if (_type == PrefabInstanceStatus.NotAPrefab) return;
        if (Application.isPlaying) return;
        SaveMesh();
        EditorUtility.SetDirty(_target);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (_type == PrefabInstanceStatus.NotAPrefab) return;
        if (Application.isPlaying) return;
        EditorGUILayout.LabelField("Mesh name : " + _target._meshName);
        if (GUILayout.Button("Delette")) DeletteObj();
    }

    private void OnSceneGUI()
    {
        if (_type == PrefabInstanceStatus.NotAPrefab) return;
        if (Application.isPlaying) return;

        if (_style == null)
        {
            _style = new GUIStyle();
            _style.fontStyle = FontStyle.Bold;
            _style.normal.textColor = Color.white;
            _style.richText = true;
        }

        EditorGUI.BeginChangeCheck();
        Vector3 _handleAPosTmp = Handles.PositionHandle(_target._handleA + _target.transform.position, Quaternion.identity);
        Vector3 _handleBPosTmp = Handles.PositionHandle(_target._handleB + _target.transform.position, Quaternion.identity);

        Handles.Label(_target._handleB + _target.transform.position, "\n Anchor A \n Move to modify size", _style);
        Handles.Label(_target._handleA + _target.transform.position, "\n Anchor B \n Move to modify size", _style);
        Handles.Label(_target.transform.position, "\n Move the entire object", _style);



        if (EditorGUI.EndChangeCheck())
        {
            _needSave = true;
            Vector2 _previousGriddSize = _target._griddSize;

            _target._handleA.y = _target.transform.position.y;
            _target._handleB.y = _target.transform.position.y;

            _target._griddSize.x = (int)(((_handleAPosTmp.x - _handleBPosTmp.x)) / _target._tileSize) + 1;

            _target._griddSize.y = (int)(((_handleAPosTmp.z - _handleBPosTmp.z) / _target._tileSize) + 1);

            _target._griddOffset.x = (int)((_handleBPosTmp.x - _target.transform.position.x) / _target._tileSize);
            _target._griddOffset.y = (int)((_handleBPosTmp.z - _target.transform.position.z) / _target._tileSize);

            if (_previousGriddSize != _target._griddSize) _target.UpdateGround();

            _target._handleA = _handleAPosTmp - _target.transform.position;
            _target._handleB = _handleBPosTmp - _target.transform.position;

        }

    }

    void CreateMesh()
    {


        if (_target._mesh != null)
        {
            _target._mesh = Instantiate(_target._mesh);
        }
        else
        {
            _target._mesh = new Mesh();
        }

        _target._mesh.name = "Ground_Mesh_" + _target._instanceID;

        _needSave = true;
    }

    void SaveMesh()
    {
        if (!_needSave || deleted) return;
        string _path = "Assets/Ground/Generated_Mesh/";
        string _completPath = "Assets/Ground/Generated_Mesh/" + _target._meshName + ".asset";

        if (!System.IO.Directory.Exists(_path)) System.IO.Directory.CreateDirectory(_path);
        if (!System.IO.File.Exists(_completPath)) AssetDatabase.CreateAsset(_target._mesh, _completPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void DeletteObj()
    {
        deleted = true;
        string _path = "Assets/Ground/Generated_Mesh/" + _target._meshName + ".asset";
        DestroyImmediate(_target.gameObject);
        AssetDatabase.DeleteAsset(_path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }
}
