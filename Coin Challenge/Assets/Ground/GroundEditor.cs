using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEditor : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _griddSize;
    [HideInInspector]
    public Vector2 _griddOffset;

    [SerializeField]
    public int _tileSize = 2;

    [HideInInspector]
    [SerializeField]
    MeshFilter _filter;

    [HideInInspector]
    [SerializeField]
    MeshCollider _col;


    // [HideInInspector]
    public Vector3 _handleA, _handleB;

    List<int> _tris;
    List<Vector2> _uvs;
    List<Vector3> _verts;
    List<Color> _colors;

    [SerializeField]
    List<Mesh> _refMeshList;

    List<GroundTileInfos> _groundTileInfosList;
    public string _meshName
    {
        get
        {
            if (_filter.sharedMesh == null) return "None";
            return _filter.sharedMesh.name;
        }
    }

    [HideInInspector]
    public int _instanceID;

    GroundTileInfos _getRandTileInfos
    {
        get
        {
            int index = Random.Range(0, _groundTileInfosList.Count);
            return _groundTileInfosList[index];
        }
    }

    public Mesh _mesh
    {
        get
        {
            return _filter.sharedMesh;
        }
        set
        {
            _filter.sharedMesh = value;
        }
    }


    private void Start()
    {
    }


    public void UpdateGround()
    {
        InitGroundTilesinfos();

        _tris = new List<int>();
        _uvs = new List<Vector2>();
        _verts = new List<Vector3>();

        for (int x = (int)_griddOffset.x; x < _griddSize.x + (int)_griddOffset.x; x++)
        {
            for (int y = (int)_griddOffset.y; y < _griddSize.y + (int)_griddOffset.y; y++)
            {
                AddTile(x * _tileSize, y * _tileSize);
            }
        }

        _colors = new List<Color>();
        for (int i = 0; i < _verts.Count; i++)
        {
            _colors.Add(new Color(Random.Range(0.75f, 1), 0, 0, 0));
        }

        Mesh _mesh = new Mesh();
        _mesh.name = _meshName;
        _mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        _mesh.SetVertices(_verts);

        _mesh.SetTriangles(_tris, 0);

        _mesh.SetUVs(0, _uvs);

        _mesh.SetColors(_colors);

        _mesh.RecalculateNormals();

        _filter.sharedMesh = _mesh;

        UpdateCollider();

    }

    void AddTile(float x, float y)
    {
        GroundTileInfos _tileInfos = _getRandTileInfos;

        int _startVertcount = _verts.Count;

        foreach (var vert in _tileInfos._refMeshVerts)
        {
            _verts.Add(vert + new Vector3(x, 0, y));
        }

        foreach (var t in _tileInfos._refMeshTris)
        {
            _tris.Add(t + _startVertcount);
        }

        foreach (var uv in _tileInfos._refMeshUVs)
        {
            _uvs.Add(uv);
        }
    }

    void UpdateCollider()
    {
        Mesh _mesh = new Mesh();
        float _meshCenterOffset = ((float)_tileSize) / 2f;

        List<Vector3> _verts = new List<Vector3>()
        {
            new Vector3(_griddOffset.x-_meshCenterOffset, 0, _griddOffset.y-_meshCenterOffset),// Low Left
            new Vector3(_griddOffset.x-_meshCenterOffset, 0, _griddOffset.y+_griddSize.y-_meshCenterOffset),// Up Left
            new Vector3(_griddOffset.x-_meshCenterOffset+_griddSize.x, 0, _griddOffset.y+_griddSize.y-_meshCenterOffset),// Up Right
            new Vector3(_griddOffset.x-_meshCenterOffset+ _griddSize.x, 0, _griddOffset.y-_meshCenterOffset),// Low Right

        };

        List<int> _tris = new List<int>() { 0, 1, 3, 3, 1, 2 };


        _mesh.SetVertices(_verts);
        _mesh.SetTriangles(_tris, 0);

        _col.sharedMesh = _mesh;
    }

    void InitGroundTilesinfos()
    {
        if (_groundTileInfosList != null && _groundTileInfosList.Count == _refMeshList.Count) return;

        _groundTileInfosList = new List<GroundTileInfos>();

        foreach (var _mesh in _refMeshList)
        {
            _groundTileInfosList.Add(new GroundTileInfos(_mesh));
        }
    }

    class GroundTileInfos
    {
        public GroundTileInfos(Mesh _mesh)
        {
            this._mesh = _mesh;

            _refMeshVerts = new List<Vector3>();
            _refMeshTris = new List<int>();
            _mesh.GetVertices(_refMeshVerts);
            _mesh.GetTriangles(_refMeshTris, 0);

            _refMeshUVs = new List<Vector2>();
            _mesh.GetUVs(0, _refMeshUVs);
        }

        public Mesh _mesh;

        public List<Vector3> _refMeshVerts;
        public List<int> _refMeshTris;
        public List<Vector2> _refMeshUVs;
    }


}
